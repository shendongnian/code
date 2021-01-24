    files.ForEach(arquivoMover =>
                {
                    var nomeArquivo = System.IO.Path.GetFileName(arquivoMover);
                    var fileExt = System.IO.Path.GetExtension(arquivoMover);
                    if(fileExt==".EXE")
                    { 
                        //is a .EXE file 
                    }
                    System.IO.File.Move(arquivoMover, System.IO.Path.Combine(caminhoRaiz, nomeArquivo));
                });
