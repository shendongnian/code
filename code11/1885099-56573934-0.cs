            private void CreateOverviewTable_Click(object sender, RoutedEventArgs e)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn();
            if (isConnected != 0)
            {
                int anzNeueVar = tableSelectedVar.Rows.Count;
                //Überprüft ob eine Variable zur Überwachung ausgewählt wurde
                if (anzNeueVar != 0)
                {
                    //Macht das dgTable1 unsichtbar und macht dgTable3 an der Stelle von dgTable1 sichtbar
                    dgTable1.Visibility = Visibility.Collapsed;
                    dgTable3.Visibility = Visibility.Visible;
                    //Erstellt ein Array welcher in der ersten Splate den Namen hat, in der zweiten die Adresse und in der dritten die Datengröße.
                    string[,] inhaltVar = new string[anzNeueVar, 3];
                    //Liest die Daten aus der Tabelle in den Array
                    for (int i = 0; i <= anzNeueVar - 1; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            inhaltVar[i, j] = tableSelectedVar.Rows[i].ItemArray[j].ToString();
                        }
                    }
                    string[,] altInhaltVar = new string[anzNeueVar, 3];
                    altInhaltVar = inhaltVar;
                    int anzAlteVar = dgTable3.Columns.Count;
                    //Erstellt eine Spalte für jeden Parameter welcher überwacht werden soll.
                    for (int k = 0; k <= (inhaltVar.GetLength(0) - 1); k++)
                    {
                        //erster Durchlauf
                        if (anzAlteVar == 0)
                        {
                            try
                            {
                                //Erstellt die Columns für jeden Parameter
                                //dgTable3.Columns.Add(inhaltVar[k, 0]);
                                tableforDataStream.Columns.Add(inhaltVar[k, 0]);
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message);
                            }
                        }
                        //min zweiter Durchlauf
                        else
                        {
                            //wenn zuviele Spalten vorhanden sind werden die übrigen gelöscht
                            if (anzAlteVar > anzNeueVar)
                            {
                                while (dgTable3.Columns.Count() != inhaltVar.GetLength(0))
                                {
                                    dgTable3.Columns.RemoveAt(0);
                                }
                            }
                            //wenn zu wenig Spalten vorhanden sind werden neue hinzugefügt 
                            if (anzAlteVar < anzNeueVar)
                            {
                                for (int j = 0; j <= dgTable3.Columns.Count - 1; j++)
                                {
                                    dgTable3.Columns[j].Header = "";
                                }
                                while (dgTable3.Columns.Count() != anzNeueVar)
                                {
                                    dgTable3.Columns.Add(textColumn);
                                }
                            }
                            //übernimmt die neuen Header in das Datagrid
                            for (int i = 0; i <= dgTable3.Columns.Count-1; i++)
                            {
                                dgTable3.Columns[i].Header = inhaltVar[i, 0];
                            }
                        }
                    }
                    //Schickt die Daten welche in Tabelle tableSelectedVar sind zur Maschine
                    if (isConnected == 1)
                    {
                        SendDataToMachine(inhaltVar);
                    }
                    else
                    {
                        MessageBox.Show("Bitte erste die Verbindung herstellen bevor Daten an die Maschine geschickt werden");
                    }
                    //TestFunktion: Sendet was auch immer im Suchtextfeld steht
                    //TestSend();
                }
                else
                {
                    MessageBox.Show("Bitte mindestens eine Variable zur Ueberwachung bestimmen", null, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Bitte erst eine Verbindung zur Maschine Herstellen");
            }
        }
