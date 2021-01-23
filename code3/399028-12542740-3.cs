    public static extern IntPtr Parse([MarshalAs(UnmanagedType.LPStr)] string s1);
                string s = Request.QueryString.Get("U");
                IntPtr i;
                {
                    i = Parse(s);
                }
                string jj =Marshal.PtrToStringAnsi(i);
                Response.Write(jj);
            }
