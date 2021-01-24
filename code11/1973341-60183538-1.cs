    public class EmployeeController : MonoBehaviour
    {
        // These you reference via the Inspector in the prefab
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI nameField;
        [SerializeField] private TextMeshProUGUI designationField;
    
        // And finally have a method you can call directly
        // Using SendMessage is very inefficient and unsecure
        public void BindData(string imageUrl, string name, string designation)
        {
            nameField.text = name;
            designationField.text = designation;
    
            // Start downloading the image
            StartCoroutine(DownloadImage(imageUrl));
        }
    
        private IEnumerator DownloadImage(string url)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
            {
                yield return www.SendWebRequest();
    
                if (www.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    // Get downloaded texture
                    var texture = DownloadHandlerTexture.GetContent(www);
    
                    // Create a sprite from the texture
                    var sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), Vector2.one * 0.5f);
    
                    // Assign it to the image
                    image.sprite = sprite;
                }
            }
        }
    }
