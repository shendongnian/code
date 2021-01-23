            Func<string> foo = () =>
                {
                    try
                    {
                        return LISTVIEW.Items[x].Text.Trim();
                    }
                    catch
                    {
                         // this is the diaper anti-pattern... fix it by adding logging and/or making the code in the try block not throw
                         return String.Empty;
                         
                    }
                };
            var ar = this.BeginInvoke(foo);
            string sub = (string)this.EndInvoke(ar);
