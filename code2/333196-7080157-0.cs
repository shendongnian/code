    foreach (Control objControl in Controls)
                    {
                        RadioButton objCurrentRadio = null;
    
                        if (objControl is RadioButton)
                        {
                            objCurrentRadio = (RadioButton)objControl;
    
                            if (objCurrentRadio == null || objCurrentRadio.Tag == null)
                                continue;
    
                            string sTag = (string)objControl.Tag;
    
                            if (sTag == _sSelectedItem)
                            {
                                objCurrentRadio.Checked = true;
                            }
                            else
                            {
                                objCurrentRadio.Checked = false;
                            }
                            
                            objCurrentRadio.TabStop = this.TabStop;
                        }
                    }
