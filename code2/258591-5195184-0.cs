    private IEnumerable<Member> GetMemberQuery()
    {
        var members = (from member in MembersItemsControl.Items
                       where
                       (
                           // Match either male or female selection
                           (member as UserInformation).sex.Equals("Male") == 
                               SeekingMale.IsChecked.Value &&
                           (member as UserInformation).sex.Equals("Female") == 
                               SeekingFemale.IsChecked.Value
                       )
                       ||
                       (
                           // Provide both male and female if both options are selected
                           SeekingMale.IsChecked.Value == true &&
                           SeekingFemale.IsChecked.Value == true
                       )
                       select member);
    
        return members;
    }
