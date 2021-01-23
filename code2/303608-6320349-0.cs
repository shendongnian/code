    public static string readListBoxSelected(ListBox listbox)
        {
            if (listbox.InvokeRequired)
            {
                return (string)listbox.Invoke(
                  new Func<String>(() => readListBoxSelected(listbox))
                );
            }
            else
            {
    if(istbox.SelectedValue != null)
    
                return  listbox.SelectedValue.ToString();
    else
    return String.Empty
            }
            }
