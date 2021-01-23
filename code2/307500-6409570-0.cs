            for (int i = 0; i < chklstTelpas.Items.Count; i++)
            {
                if (chklstTelpas.Items[i].Selected)
                {
                    chklstTelpas.Items[i].Attributes.Add("style", "background-color: red;");
                }
                else
                {
                    chklstTelpas.Items[i].Attributes.Add("style", "background-color: white;");
                }
            }
