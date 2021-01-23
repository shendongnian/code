    protected void btnRemove_Click(object sender, EventArgs e)
    {
        ArrayList cart = (ArrayList) Session["scart"];
        foreach (DictionaryEntry item in cart) {
            if ((string) item.Key == lbCheckOut.SelectedItem.Text) {
                cart.Remove(item);
                break;
            }
        }
    }
