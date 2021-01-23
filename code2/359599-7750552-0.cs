    Invoke(new Action(
        () => 
        {
            checkedListBox1.Items.RemoveAt(i);
            checkedListBox1.Items.Insert(i, temp + validity);
            checkedListBox1.Update();
        }
    )
    );
