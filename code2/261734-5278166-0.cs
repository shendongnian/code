            bool GetUsernamePassword(string line, ref string uname, ref string pwd)
            {
                int idx = line.IndexOf(':') ;
                if (idx == -1)
                    return false;
                uname = line.Substring(0, idx);
                pwd = line.Substring(idx + 1);
                return true;
            }
.
                string username_password = "username:password";
                string uname = String.Empty;
                string pwd = String.Empty;
                if (!GetUsernamePassword(username_password, ref uname, ref pwd))
                {
                    // Handle error: incorrect format
                }
                Console.WriteLine("{0} {1} {2}", username_password, uname, pwd);
