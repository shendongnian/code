    public bool CanMoveItemFromList1ToList2
    {
       { get { return SelectedItem1 != null; }
    }
    public void MoveItemFromList1ToList2()
    {
       List2.Add(SelectedItem1);
       List1.Remove(SelectedItem1);
    }
