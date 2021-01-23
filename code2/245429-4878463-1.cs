    var c2010 = formsEntities2010.Clients
                    .Join( formsEntities1010.Agent_Client
                                            .Where( ac => ac.Agent_ID == a.Agent_ID ),
                           c => c.Client_ID,
                           ac => ac.Client_ID,
                           (c,ac) => c )
                    .Cast<Forms2010.Client>(); // or whatever namespace you choose
