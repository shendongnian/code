          //imagem inicial de cada contacto, caso esta não tenha imagem de perfil.
                var aux = ImageSource.FromResource("KiaiDay.Images.user.png");
                var ListContactos = new List<Contacto>();
                foreach (var c in contactosE)
                {
                    aux = ImageSource.FromResource("KiaiDay.Images.user.png");
                    if (c.PhotoUri != null)
                    {
                        //caso tenho imagem de perfil, aceder ao caminho real no ficheiro e extrair a imagem
                        var contentLoader = DependencyService.Get<IContentLoader>();
                        var uri = new Uri(c.PhotoUri);
                        aux = contentLoader.LoadFromContentUri(uri);
                    }
    
                    // Add method inside foreach generate too many innecesary property changed
                    // notifications
                    ListContactos.Add(
                        new Contacto()
                        {
                            Email = c.Email,
                            Foto = aux,
                            Numero = c.Number,
                            Nome = c.Name,
                            Opcao = AppResource.Select
                        });
                }
    
                ObterContactos = new ObservableCollection<Contacto>(ListContactos);
            }
            else
    ...
