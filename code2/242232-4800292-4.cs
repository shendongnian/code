    using System.Text.RegularExpressions;
    namespace myNameSpace
    {
        public class myClass
        {
            public bool myMethod(string[] boxes)
            {
                bool result=true;
                try
                {
                    string pays=@"ES
                    FR
                    EN
                    "
                    Regex regex=new Regex(@"^[A-Za-z]
                    {
                        2
                    }
                    $");
                    result=regex.IsMatch(boxes[0]);
                    if (result)
                    {
                        regex=new Regex(@"^"+boxes[0]+@".$",RegexOptions.Multiline);
                        result=regex.Matches(pays).Count!=0;
                    }
                }
                catch
                {
                    result=false;
                }
                return result;
            }
        }
    }
