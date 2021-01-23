       var inputFromUser = Int32.Parse( combobox1.SelectedText );
       var linQuery = from cq in dbContext.tblCharacteristics
                        where cq.CharacteristicID == inputFromUser
                        select new
                        {
                            CharacteristicIDs = cq.CharID,
                            CharacteristicNames = cq.CharName
                        };
