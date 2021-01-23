    for (int index = 0; index < listBox1.Items.Count; index++ )
    {
       Object o = (int)listBox1.Items[index];
       if ( /* criteria you want here */ )
       {
           listBox1.SetSelected(index, true);
       
   }
}
