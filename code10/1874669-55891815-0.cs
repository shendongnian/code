    public class DataInserter : MonoBehaviour
    {
        public InputField inputUserName;
        public InputField inputEmail;
    
        string CreateUserURL = "http://localhost/balikaral/insertAccount.php";
    
        public void CreateUser()
        {
            var userName = inputUserName.text;
            var email = inputEmail.text;
    
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", username);
            form.AddField("emailPost", email);
    
            WWW www = new WWW(CreateUserURL, form);
        }
    }
