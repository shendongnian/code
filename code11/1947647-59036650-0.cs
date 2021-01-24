    private void OnDeleteVictimExecuted(object InvNum)
        {
            Relationship.Items.Clear();
            //
            //  This method is called to set the default relationship for victim-to-suspect.  
            //  It is called when either the SelectedVictim or SelectedSuspect properties are set.  
            //  It searches the relationships collection by victim involvement number and suspect 
            //      involvement number. 
            //  When a match is found on both involvement numbers, it sets the SelectedRelationship 
            //      property to the relationship in the relationships collection.  
            //   If no match is found, nothing happens.
            // 
            int a = this.Relationships.Count;
            this.SelectedRelationship = null;
            //if ((this.SelectedSuspect != null) & (this.SelectedVictim != null))
            //{
            //    for (int i = 0; i < this.Relationships.Count; i++)
            //    {
            //        if (this.Relationships[i].SuspectNumber == this.SelectedSuspect.InvolvementNumber)
            //            if (this.Relationships[i].VictimNumber == this.SelectedVictim.InvolvementNumber)
            //                this.SelectedRelationship = null;
            //    }
            //}
        }
