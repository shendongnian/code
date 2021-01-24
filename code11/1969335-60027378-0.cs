c#
public class MouseMover
        {
            public int PageHeight { get; private set; }
            public int PageScrolled { get; private set; }
            public int WindowHeight { get; private set; }
            public int MouseXCurr { get; private set; } // current mouse x position
            public int MouseYCurr { get; private set; } // current mouse y position
            private int MouseXToMove { get; set; }
            private int MouseYToMove { get; set; }
            private ChromeDriver Chr { get; set; }
            private Actions click;
            public MouseMover(ChromeDriver chr)
            {
                MouseXCurr = 0;
                MouseYCurr = 0;
                MouseXToMove = 0;
                MouseYToMove = 0;
                Chr = chr;
                NewPage();
                click = new Actions(chr);
                click.Click().Build();
            }
            public void NewPage() // call this whenever entering a new page and it is fully loaded in
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Chr;
                Int64.TryParse(js.ExecuteScript("" +
                "var body = document.body," +
                "    html = document.documentElement;" +
                "" +
                "var height = Math.max(body.scrollHeight, body.offsetHeight," +
                "                         html.clientHeight, html.scrollHeight, html.offsetHeight);" +
                "return height;").ToString(), out long ph);
                PageHeight = (int)ph;
                if (PageScrolled != 0)
                {
                    MouseYCurr -= PageScrolled;
                }
                PageScrolled = 0;
                Int64.TryParse(js.ExecuteScript("return window.innerHeight;").ToString(), out long wh);
                WindowHeight = (int)wh;
            }
            public void Click() // click at the current mouse position
            {
                click.Perform();
            }
            public void Scroll(int y) // scroll the page by y pixels down (negative to scroll up)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Chr;
                int oldScroll = PageScrolled;
                if (y > 0)
                {
                    if (PageScrolled + WindowHeight + y <= PageHeight)
                    {
                        js.ExecuteScript("window.scrollBy(0," + y + ")");
                        PageScrolled += y;
                        // sometimes the ScrollHeight gets messed up. This helps to fix it, but it doesn't always fix it
                        Int64.TryParse(js.ExecuteScript("return (window.pageYOffset || document.documentElement.scrollTop)  - (document.documentElement.clientTop || 0);").ToString(), out long s);
                        if (s != 0 && PageScrolled != (int)s)
                        {
                            PageScrolled = (int)s;
                        }
                        MouseYCurr += PageScrolled - oldScroll;
                    }
                    else
                    {
                        if (PageHeight != PageScrolled + WindowHeight)
                        {
                            js.ExecuteScript("window.scrollBy(0," + (PageHeight - (PageScrolled + WindowHeight)) + ")");
                            PageScrolled += (PageHeight - (PageScrolled + WindowHeight));
                        // sometimes the ScrollHeight gets messed up. This helps to fix it, but it doesn't always fix it
                            Int64.TryParse(js.ExecuteScript("return (window.pageYOffset || document.documentElement.scrollTop)  - (document.documentElement.clientTop || 0);").ToString(), out long s);
                            if (s != 0 && PageScrolled != (int)s)
                            {
                                PageScrolled = (int)s;
                            }
                            MouseYCurr += PageScrolled - oldScroll;
                        }
                    }
                }
                else
                {
                    if (PageScrolled >= -y)
                    {
                        js.ExecuteScript("window.scrollBy(0," + y + ")");
                        PageScrolled += y;
                        // sometimes the ScrollHeight gets messed up. This helps to fix it, but it doesn't always fix it
                        Int64.TryParse(js.ExecuteScript("return (window.pageYOffset || document.documentElement.scrollTop)  - (document.documentElement.clientTop || 0);").ToString(), out long s);
                        if (s != 0 && PageScrolled != (int)s)
                        {
                            PageScrolled = (int)s;
                        }
                        MouseYCurr += PageScrolled - oldScroll;
                    }
                    else
                    {
                        js.ExecuteScript("window.scrollBy(0," + -PageScrolled + ")");
                        PageScrolled -= PageScrolled;
                        // sometimes the ScrollHeight gets messed up. This helps to fix it, but it doesn't always fix it
                        Int64.TryParse(js.ExecuteScript("return (window.pageYOffset || document.documentElement.scrollTop)  - (document.documentElement.clientTop || 0);").ToString(), out long s);
                        if (s != 0 && PageScrolled != (int)s)
                        {
                            PageScrolled = (int)s;
                        }
                        MouseYCurr += PageScrolled - oldScroll;
                    }
                }
            }
            public void MoveTo(IWebElement el) // move to the middle of the given web element
            {
                MoveTo(el.Location.X + el.Size.Width / 2, el.Location.Y + el.Size.Height / 2);
            }
            public void MoveTo(int x, int y) // move to the given page coordinates
            {
                MouseXToMove = x - MouseXCurr;
                MouseYToMove = y - MouseYCurr;
                Move();
            }
            void Move()
            {
                bool retry;
                do
                {
                    try
                    {
                        retry = false;
                        Actions actions = new Actions(Chr);
                        actions.MoveByOffset(MouseXToMove, MouseYToMove).Build().Perform();
                        // this will only be executed when the target coordinates enter the screen
                        MouseXCurr += MouseXToMove;
                        MouseYCurr += MouseYToMove;
                        MouseXToMove = 0;
                        MouseYToMove = 0;
                    }
                    catch
                    {
                        retry = true;
                        if (MouseYToMove > 0)
                        {
                            int oldScroll = PageScrolled;
                            Scroll(50);
                            MouseYToMove -= PageScrolled - oldScroll;
                        }
                        else
                        {
                            int oldScroll = PageScrolled;
                            Scroll(-50);
                            MouseYToMove -= PageScrolled - oldScroll;
                        }
                    }
                }
                while (retry == true);
            }
        }
