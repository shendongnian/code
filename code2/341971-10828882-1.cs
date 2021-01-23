                string contentDisposition = resp.Headers["Content-Disposition"];
                string fileName = string.Empty;
                if (!string.IsNullOrEmpty(contentDisposition))
                {
                    string lookFor = "filename=";
                    int index = contentDisposition.IndexOf(lookFor, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                        fileName = contentDisposition.Substring(index + lookFor.Length).Replace("\"", ""); ;
                } 
