    public static int GetBoundFieldIndexByName(this GridView gv,string name)
        {
            int index = 0;
            bool found = false;
            foreach (DataControlField c in gv.Columns)
            {
                if (c is BoundField)
                {
                    BoundField field = (BoundField)c;
                    if (name == field.DataField ||
                        name == field.SortExpression ||
                        name == field.HeaderText)
                    {
                        found = true;
                        break;
                    }
                }
                index++;
            }
            return found ? index : -1;
        }
