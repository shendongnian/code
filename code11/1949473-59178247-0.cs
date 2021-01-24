    // Instanciating with base URL
                FirebaseDB firebaseDB = new FirebaseDB("Firebase Base link");
    
                // Referring to Node with name "Teams"
                FirebaseDB firebaseDBTeams = firebaseDB.Node("Teams");
                var data = @"{
                                'Team-Awesome': {
                                    'Members': {
                                        'M1': {
                                            'City': 'Giza',
                                            'Name': 'Isaac'
                                            },
                                        'M2': {
                                            'City': 'Cairo',
                                            'Name': 'Be'
                                            },
                                        'M3': {
                                            'City': 'France',
                                            'Name': 'Pradeep'
                                            }
                                       }
                                   }
                              }";
    
               
    
                WriteLine("POST Request");
                FirebaseResponse postResponse = firebaseDBTeams.Post(data);
                WriteLine(postResponse.Success);
                WriteLine();
