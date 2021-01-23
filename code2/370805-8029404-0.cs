    int i = 0;
    foreach (var question in _viewModel.Questions)
                {
                    //build question label
                    var questionLabel = new Label();
                    questionLabel.Text = question.Text;
                    questionLabel.Tag = question.Id;
    
                    //build answer combobox
                    var answerCombo = CreateQuestionComboBox(question);
    
                    //put question and answer into panel            
                    var controlPanel = new Panel();
                    controlPanel.Tag = question.Id;
                    controlPanel.AutoSize = true;
                    controlPanel.Controls.Add(questionLabel);
                    controlPanel.Controls.Add(answerCombo);
    
                    //add panels to flowpanel
                    tableLayoutPanel1.SetRow(controlPanel, i);
                    tableLayoutPanel1.RowCount = i++;
                }
