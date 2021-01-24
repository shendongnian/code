    using System.Linq;
    bool CancelRequired = false;
    while ( !CancelRequired )
      foreach ( var item in listBox1.Items )
        MessageBox.Show(item.ToString());
