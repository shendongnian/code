                    foreach (var item in ilist)
                    {
                        var cb = new CheckBox();
                        cb.Tag = item;
                        _dropDown.AddControl(cb);
                        //* Todo: Could not get binding to work
                        //var b = new Binding("Text", item, this.DisplayMember);
                        //cb.DataBindings.Add(b);
                        try
                        {
                            cb.Text = item.GetType()
                                .GetProperty(this.DisplayMember ?? string.Empty)
                                .GetValue(item, new object[] { }).ToString();
                        }
                        catch { cb.Text = string.Empty; }
                    }
