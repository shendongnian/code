    void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
    
              // This event is raised for the header, the footer, separators, and items.
    
              // Execute the following logic for Items and Alternating Items.
              if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                 string question = (string)e.Item.DataItem;
                 Literal litQuestion = (Literal) e.Item.FindControl("litQuestion");
                 litQuestion.Text = question;
    
                 PlaceHolder phRow = (PlaceHolder) e.Item.FindControl("phRow");
    
                 if (question.StartsWith("something")){
                     phRow.Controls.Add(new RadioButton("blabla"));
                 }
    
                 if (((Evaluation)e.Item.DataItem).Rating == "Good") {
                    ((Label)e.Item.FindControl("RatingLabel")).Text= "<b>***Good***</b>";
                 }
              }
           }   
