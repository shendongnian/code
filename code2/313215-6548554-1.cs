            var conditions = new List<Conition>
            {
                new Conition
                    {
                        Match = formvalues["helmets"] == "" && formvalues["garages"] == "",
                        Action = () =>
                                     {
                                          ViewBag.hideHelmet = 1;    
                                          ViewBag.hideGarages = 1;
                                          ViewBag.SelectedHelmets = 1;
                                          ...
                                     }
                    },
                new Conition
                    { ...
             };
