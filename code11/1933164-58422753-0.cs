    <form>
            <p>@question</p>
    
            @foreach (var item in Enum.GetNames(typeof(Question.Colors)))
            {
                <div>
                    <input type="radio" name="question1" id="@item" value="@item" @onchange="SelectionChanged" checked=@(selectedAnswer.Equals(item,StringComparison.OrdinalIgnoreCase)) />
                    <label for="@item">@item</label>
                </div>
            }
            <div>
                <label>Selected answer is @selectedAnswer</label>
            </div>
    
            <button type="button" @onclick="@OnSubmit">Submit</button>
    
    
        </form>
    
    
    
    
    @code {
        string selectedAnswer = "";
        void SelectionChanged(ChangeEventArgs args)
        {
            selectedAnswer = args.Value.ToString();
        }
    
    
        Question question = new Question { QuestionText = "What is the color of the sky" };
    
       
        public void OnSubmit()
        { 
    
              Console.WriteLine(selectedAnswer);
            
        }
    
        public class Question
        {
    
            public string QuestionText { get; set; }
            public enum Colors { Red, Green, Blue, Yellow };
    
        }
    }
