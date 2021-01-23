    RadioButton btn = sender as RadioButton;
    if(btn!= null && btn.IsChecked)
    {
       Switch(btn.Name)
       {
          case "rbFrenchImpl":
          break;
          ...
       }
    }
