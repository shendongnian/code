    public partial class ProgressDialog : Form
    {
        //public delegate delSetProgress 
    private readonly int progressBarMax;
    /// <summary>
    /// Structure used for passing progress bar related parameters as a single variable.
    /// </summary>
    public struct ProgressBarParams
    {
        public int value;
        public string message;
        public ProgressBarParams(string Message, int Value)
        {
            message = Message;
            value = Value;
        }
    }
    /// <summary>
    /// Constructs the progress bar dialog and sets the progress bar's maximum value to maxValue.
    /// </summary>
    /// <param name="maxValue">Value to set to progress bar's Maximum property.</param>
    public ProgressDialog(int maxValue)
    {
        InitializeComponent();
        progressBarMax = maxValue;
    }
    private void ProgressDialog_Load(object sender, EventArgs e)
    {
        progressBar.Maximum = progressBarMax;
    }
    /// <summary>
    /// Public method to update the progressDialog
    /// </summary>
    /// <param name="inputParams">Values to update on the progressDialog</param>
    public void SetProgress(ProgressBarParams inputParams)
    {
        lblMessage.Text = inputParams.message;
        progressBar.setValue(inputParams.value);
        Update();
    }
    /// <summary>
    /// This method should be called when the operation represented by the ProgressDialog is
    /// completed. It shows an "operation complete" message for a second and then closes the form.
    /// </summary>
    public void Finish()
    {
        lblMessage.Text = "Operation complete.";
        progressBar.setValue(progressBar.Maximum);
        Update();
        System.Threading.Thread.Sleep(1000);
            this.Close();
        }
    }
    public static class MyExtensions
    {
        /// <summary>
        /// Implements a hack to get around a stupid rendering problem with the .NET progress bar in some environments.
        /// Sets the progress bar value property.
        /// </summary>
        /// <param name="proBar">Progress bar control to set the value on.</param>
        /// <param name="value">Value to be set.</param>
        public static void setValue(this ProgressBar proBar, int value)
        {
            if (value > 0)
            {
                proBar.Value = value;
                proBar.Value = value - 1;
                proBar.Value = value;
            }
            else
            {
                proBar.Value = value;
                proBar.Value = value + 1;
                proBar.Value = value;
            }
        }
    } 
    
