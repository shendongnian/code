                    case "Light":
                        mergedDictionaries.Add(new LightTheme());
                        App.IsLightTheme = true;
                       
                        //change theme here
                         viewmodel.changeTheme(true);
                        break;
                    case "Dark":
                        mergedDictionaries.Add(new DarkTheme());
                        App.IsLightTheme = false;
                        //change theme here
                         viewmodel.changeTheme(false);
                        break;
