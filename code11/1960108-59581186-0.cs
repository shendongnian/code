                    if (listBox1.Items.Count != 5)
                    {
                        string sbj_inc = textBox7.Text;
    
                        switch (sbj_inc)
                        {
                            case "Physics":
                                if (label21.Text != "25"){
									phy = phy + 1;
									label21.Text = phy.ToString();
									listBox1.Items.Add(textBox7.Text + "\t" + textBox8.Text);
								}
                                break;
    
                            case "Chemistry":
							    if (label20.Text != "25"){
									che = che + 1;
									label20.Text = che.ToString();
									listBox1.Items.Add(textBox7.Text + "\t" + textBox8.Text);
								}
                                break;
    
                            case "English":
								if (label19.Text != "25"){
									eng = eng + 1;
									label9.Text = eng.ToString();
									listBox1.Items.Add(textBox7.Text + "\t" + textBox8.Text);
								}
                                break;
    
                            case "Mandarin":
								if (label18.Text != "25"){
									bc = bc + 1;
									label18.Text = bc.ToString();
									listBox1.Items.Add(textBox7.Text + "\t" + textBox8.Text);
								}
                                break;
    
                            case "Melayu":
								if (label17.Text != "25"){
									bm = bm + 1;
									label17.Text = bm.ToString();
									listBox1.Items.Add(textBox7.Text + "\t" + textBox8.Text);
								}
                                break;
    
                            default:
                                MessageBox.Show("Invalid Subject");
                                break;
                        }
                    }
    
                    else
                    {
                        MessageBox.Show("Maximum 4 Subjects can be chosen !");
                    }
