    diff --git a/Roulette/Roulette.cs b/Roulette/Roulette.cs
    index d5ede34..ae098ac 100644
    --- a/Roulette/Roulette.cs
    +++ b/Roulette/Roulette.cs
    @@ -402,6 +402,7 @@ namespace Roulette
                            //
                            // TODO: Add any constructor code after InitializeComponent call
                            //
    +                       Application.Idle += (sender, e) => DisplayResultsEx();
                    }
     
                    /// <summary>
    @@ -5135,6 +5136,11 @@ namespace Roulette
     
                    public void DisplayResults()
                    {
    +
    +               }
    +
    +               private void DisplayResultsEx()
    +               {
                            //Display the current result.
                            lblCurrentResult.Text = m_Wheel1.CurrentResult.Name;
     
