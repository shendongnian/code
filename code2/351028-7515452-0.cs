                if (fileText.EndsWith("_1"))
                {
                    selectedFile.NextNode.Remove();
                    selectedFile.Remove();
                }
                else
                {
                    selectedFile.PrevNode.Remove();
                    selectedFile.Remove();
                }
