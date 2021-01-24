    try this, it will work
          @{ 
          for (int i = 0; i < Model.Answers.Count; i++)
            {
                <div>
                    @if(Model.Answers[i].Checked)
                    {
                    @Html.RadioButtonFor(model => Model.Name,Model.Answers[i].Id, new { id = "answer" +i})
                    }
                  
                </div>
            }
        }
