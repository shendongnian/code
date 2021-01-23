                    //var style = new Style(typeof(TextBox));
                    ctrl = new AutoCompleteBox { FontSize = 14, MaxDropDownHeight = 90, Name = c.ControlID };
                    ctrl.TabIndex = c.TabOrder;
                    ctrl.MaxWidth = 200;
                    ctrl.IsTabStop = true;
                  
                    var style = new Style(typeof(TextBox));
                    var binding = new Binding("TabIndex") { ElementName = c.ControlID };
                    var setter = new Setter(TextBox.TabIndexProperty, binding);
                    style.Setters.Add(setter);
                    (ctrl as AutoCompleteBox).TextBoxStyle = style;
                    if (c.SpName != null && c.DisplayMember != null)
                    {
                        DataTable dt = sqlHelper.ExecuteSelectProcedure(c.SpName);
                        var cmb = ctrl as AutoCompleteBox;
                        cmb.ItemsSource = dt.AsEnumerable().Select(r => r.Field<string>(c.DisplayMember)).ToList();
                    }
                }
