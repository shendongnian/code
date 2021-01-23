    public class UploadFileDialogHandler : BaseDialogHandler
        {
            private const int WmSettext = 0x000C;
    
            private string fileName;
            private bool _processed = false;
            public override bool HandleDialog(Window window)
            {
                var button = GetOpenButton(window);
                if (button != null)
                {
                    if (_processed == false)
                    {
                        var fileNameHandle = NativeMethods.GetChildWindowHwnd(window.Hwnd, "Edit");
                        var fileNameHwnd = new Hwnd(fileNameHandle);
                        fileNameHwnd.SetFocus();
    
                        _processed = true;
                        //MessageBox.Show("About to send " + fileName);
    
                        fileNameHwnd.SendString(fileName);
    
                        button.Click();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public UploadFileDialogHandler(string file)
            {
                fileName = "";
                fileName = file;
                //MessageBox.Show("Setting filename: " + fileName);
            }
    
            public override bool CanHandleDialog(Window window)
            {
                return GetOpenButton(window) != null;
            }
    
            private WinButton GetOpenButton(Window window)
            {
                var windowButton = new WindowsEnumerator().GetChildWindows(window.Hwnd, w => w.ClassName == "Button" && new WinButton(w.Hwnd).Title == "&Open").FirstOrDefault();
                if (windowButton == null)
                    return null;
                else
                    return new WinButton(windowButton.Hwnd);
            }
        }
    }
