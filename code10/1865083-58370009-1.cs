    private void ExportImages()
            {
                var path = Application.persistentDataPath;
                for (var i = 0; i < CamImage.AllData.Count; i++)
                {
                    byte[] imOut = CamImage.AllData[i];
                    string fileName = "/IMG" + i + ".jpg";
                    File.WriteAllBytes(path + fileName, imOut);
                    string messge = "Succesfully Saved Image To " + path + "\n";
                    Debug.Log(messge);
                }
            }
