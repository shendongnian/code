    private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");
                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();
                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }
            else
            {
                appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signaturer";
                signature = string.Empty;
                diInfo = new DirectoryInfo(appDataDir);
                if (diInfo.Exists)
                {
                    FileInfo[] fiSignature = diInfo.GetFiles("*.htm");
                    if (fiSignature.Length > 0)
                    {
                        StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                        signature = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(signature))
                        {
                            string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                            signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                        }
                    }
                }
            }
            if (signature.Contains("img"))
            {
                int position = signature.LastIndexOf("img");
                int position1 = signature.IndexOf("src", position);
                position1 = position1 + 5;
                position = signature.IndexOf("\"", position1);
                billede1 = appDataDir.ToString() + "\\" + signature.Substring(position1, position - position1);
                position = billede1.IndexOf("/");
                billede1 = billede1.Remove(position, 1);
                billede1 = billede1.Insert(position, "\\");
                billede1 = System.Web.HttpUtility.UrlDecode(billede1);
                position = signature.LastIndexOf("imagedata");
                position1 = signature.IndexOf("src", position);
                position1 = position1 + 5;
                position = signature.IndexOf("\"", position1);
                billede2 = appDataDir.ToString() + "\\" + signature.Substring(position1, position - position1);
                position = billede2.IndexOf("/");
                billede2 = billede2.Remove(position, 1);
                billede2 = billede2.Insert(position, "\\");
                billede2 = System.Web.HttpUtility.UrlDecode(billede2);
            }
            return signature;
        }
