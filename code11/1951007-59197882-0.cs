    private void btnAffFiles_Click(object sender, EventArgs e)
        {
            List<IList<Google.Apis.Drive.v3.Data.File>> ListFiles = Manip_GDrive.GetListElem("",1000);
            for (int i=0; i < ListFiles.Count; i++)
            {
                RTBFiles.Text = RTBFiles.Text + "\nPage N° : " + (int)(i+1);
                if (ListFiles[i] != null && ListFiles[i].Count > 0)
                {
                    foreach (var file in ListFiles[i])
                    {
                        Console.WriteLine("File Name : " + file.Name + " // File Id : " + file.Id);
                        RTBFiles.Text = RTBFiles.Text + "\nFile Name : " + file.Name + " // File Id : " + file.Id;
                    }
                }
            }
        }
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "my-project";
        public static List<IList<Google.Apis.Drive.v3.Data.File>> GetListElem(string parentFolderId, int pageSize)
        {
            List<IList<Google.Apis.Drive.v3.Data.File>> listAllElem = new List<IList<Google.Apis.Drive.v3.Data.File>>();
            try
            {
                if (InternetCnxState() == true)
                {
                    DriveService service = Manip_GDrive.UserCredentialService("client_id.json");
                    string pageToken = null;
                    do //loop for all pages 
                    {
                        var listRequest = service.Files.List();
                        if (parentFolderId != "") { listRequest.Q = "'" + parentFolderId + "' in parents"; }
                        listRequest.Spaces = "drive";
                        listRequest.PageSize = pageSize;
                        listRequest.Fields = "nextPageToken, files(id, name)";
                        listRequest.PageToken = pageToken;
                        var result = listRequest.Execute();
                        listAllElem.Add(result.Files);
                        pageToken = result.NextPageToken;
                    } while (pageToken != null);
                }
                else
                {
                    MessageBox.Show("Pas de connexion internet! \nVeuillez vérifier votre connexion internet avant de réessayer", "Hmidi Amine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreure s'est produite! \nCode d'erreur : " + e.Message, "Hmidi Amine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listAllElem;
        }
        public static DriveService UserCredentialService(string streamJsonPath)
        {
            UserCredential credential;
            using (var stream = new FileStream(streamJsonPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                    Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }
