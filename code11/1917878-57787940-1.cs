 lang-html
<input type="button" value="Create" onclick="submitForms();" />
 lang-js
<script>
    // Submit multiple forms
    function submitForms()
    {
        submitForm(document.getElementById('adresse'));
        submitForm(document.getElementById('person'));
        submitForm(document.getElementById('kontodaten'));
        submitForm(document.getElementById('firma'));
    } // End of the submitForms method
    // Submit a form
    function submitForm(form) {
        // Disable buttons
        disableButtons();
        // Get form data
        var fd = new FormData(form);
        // Post form data
        var xhr = new XMLHttpRequest();
        xhr.open('POST', form.getAttribute('action'), true);
        xhr.onload = function () {
            if (xhr.status === 200) {
                // Get the response
                var data = JSON.parse(xhr.response);
                // Check the success status
                if (data.success === true) {
                    // Check if we should redirect the user or show a message
                    if (data.url !== null && data.url !== '') {
                        // Redirect the user
                        location.href = data.url;
                    }
                    else {
                        // Output a success message
                        annytab.notifier.show('success', data.message);
                    }
                }
                else {
                    // Output error information
                    annytab.notifier.show('error', data.message);
                }
            }
            else {
                // Output error information
                annytab.notifier.show('error', xhr.status + " - " + xhr.statusText);
            }
            // Enable buttons
            enableButtons();
        };
        xhr.onerror = function () {
            // Output error information
            annytab.notifier.show('error', xhr.status + " - " + xhr.statusText);
            // Enable buttons
            enableButtons();
        };
        xhr.send(fd);
    } // End of the submitForm method
 lang-c#
public class ResponseData
{
    #region variables
    public bool success { get; set; }
    public string id { get; set; }
    public string message { get; set; }
    public string url { get; set; }
    #endregion
    #region Constructors
    public ResponseData()
    {
        // Set values for instance variables
        this.success = false;
        this.id = "";
        this.message = "";
        this.url = "";
    } // End of the constructor
    public ResponseData(bool success, string id, string message, string url = "")
    {
        // Set values for instance variables
        this.success = success;
        this.id = id;
        this.message = message;
        this.url = url;
    } // End of the constructor
    #endregion
    #region Get methods
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    } // End of the ToString method
    #endregion
} // End of the class
 lang-c#
// Return a success response
return Json(data: new ResponseData(true, "", "Everyting was perfect"));
