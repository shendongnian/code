    public const string ScriptTxt = @"
    luanet.load_assembly ""System.Windows.Forms""
    luanet.load_assembly ""System.Drawing""
    
    Form = luanet.import_type ""System.Windows.Forms.Form""
    Button = luanet.import_type ""System.Windows.Forms.Button""
    Point = luanet.import_type ""System.Drawing.Point""
    MessageBox = luanet.import_type ""System.Windows.Forms.MessageBox""
    MessageBoxButtons = luanet.import_type ""System.Windows.Forms.MessageBoxButtons""
    
    form = Form()
    form.Text = ""Hello, World!""
    button = Button()
    button.Text = ""Click Me!""
    button.Location = Point(20,20)
    button.Click:Add(function()
            MessageBox:Show(""Clicked!"", """", MessageBoxButtons.OK) -- this will throw an ex
        end)   
    form.Controls:Add(button)
    form:ShowDialog()";
    
            private static void Main(string[] args)
            {
                try
                {
                    var lua = new Lua();
                    lua.DoString(ScriptTxt);
                }
                catch(LuaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    if (ex.Source == "LuaInterface")
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
    
                Console.ReadLine();
            } 
