    using Firebase;
    using Firebase.Database;
    using Firebase.Storage;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.UI;
    using Firebase.Unity.Editor;
    
    public class Gallery_EN : MonoBehaviour
    {
        [SerializeField]
        public RawImage img;
        public RawImage img2;
        public RawImage img3;
        Texture2D texture;
        FirebaseStorage storage;
        StorageReference storage_ref;
        Texture2D t;
        Texture2D tt;
        Texture2D ttt;
        private Texture2D target1;
        private Texture2D target2;
        private Texture2D target3;
        public byte[] fileContents1;
        public byte[] fileContents2;
        public byte[] fileContents3;
        public RawImage imgLoad1;
        public RawImage imgLoad2;
        public RawImage imgLoad3;
        void Awake()
        {
            UnityThread.initUnityThread();
           
            storage = FirebaseStorage.DefaultInstance;
            storage_ref = storage.GetReferenceFromUrl("gs://kataraproject-a233a.appspot.com");
    
        }
        private void Start()
        {
    
            
        }
        private void OnEnable()
        {
            int height = 1024;
            int width = 1024;
    
            target1 = new Texture2D(height, width, TextureFormat.RGB24, false);
            target2 = new Texture2D(height, width, TextureFormat.RGB24, false);
            target3 = new Texture2D(height, width, TextureFormat.RGB24, false);
            const long maxAllowedSize = 1 * 1024 * 1024;
            storage_ref.Child(InputManager.ButtonName).Child("img1.png").GetBytesAsync(maxAllowedSize).
              ContinueWith((Task<byte[]> task) =>
              {
                  UnityThread.executeInUpdate(() =>
                  {
                      if (task.IsFaulted || task.IsCanceled)
                      {
                          Debug.Log(task.Exception.ToString());
                      }
                      else
                      {
                          fileContents1 = task.Result;
                          target1.LoadImage(fileContents1);
                          imgLoad1.texture = target1;
    
                          Debug.Log("Finished downloading!");
                      }
                  });
              });
            storage_ref.Child(InputManager.ButtonName).Child("img2.png").GetBytesAsync(maxAllowedSize).
            ContinueWith((Task<byte[]> task) =>
            {
                UnityThread.executeInUpdate(() =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        Debug.Log(task.Exception.ToString());
                    }
                    else
                    {
                        fileContents2 = task.Result;
                        target2.LoadImage(fileContents2);
                        imgLoad2.texture = target2;
    
                        Debug.Log("Finished downloading!");
                    }
                });
            });
            storage_ref.Child(InputManager.ButtonName).Child("img3.png").GetBytesAsync(maxAllowedSize).
           ContinueWith((Task<byte[]> task) =>
           {
               UnityThread.executeInUpdate(() =>
               {
                   if (task.IsFaulted || task.IsCanceled)
                   {
                       Debug.Log(task.Exception.ToString());
                   }
                   else
                   {
                       fileContents3 = task.Result;
                       target3.LoadImage(fileContents3);
                       imgLoad3.texture = target3;
    
                       Debug.Log("Finished downloading!");
                   }
               });
           });
            //target.LoadRawTextureData(fileContents);
            //target.Apply();
            //target.EncodeToJPG();
            //imgLoad.texture = target;
    
    
    
    
    
    
    
    
    
    
    
    
            Debug.Log("Finished downloading!");
        }
        // Start is called before the first frame update
        public void DoIt()
        {
            NativeGallery.GetImageFromGallery((path) =>
            {
                Debug.Log("Image path: " + path);
                if (path != null)
                {
                    //  imagePath = path;
                    // Create Texture from selected image
                    texture = NativeGallery.LoadImageAtPath(path, 1024); // image will be downscaled if its width or height is larger than 1024px
                    if (texture == null)
                    {
                        Debug.Log("Couldn't load texture from " + path);
                        return;
                    }
                    img.texture = texture;
                    t = TextureToTexture2D(img.texture);
    
                    // Use 'texture' here
                    // ...
                }
            }, title: "Select single image", mime: "image/*");
    
    
    
    
        }
    
        public void DoItt()
        {
            NativeGallery.GetImageFromGallery((path) =>
            {
                Debug.Log("Image path: " + path);
                if (path != null)
                {
                    // Create Texture from selected image
                    Texture2D texturee = NativeGallery.LoadImageAtPath(path, 1024); // image will be downscaled if its width or height is larger than 1024px
                    if (texturee == null)
                    {
                        Debug.Log("Couldn't load texture from " + path);
                        return;
                    }
                    img2.texture = texturee;
                    tt = TextureToTexture2D(img2.texture);
    
                    // Use 'texture' here
                    // ...
                }
            }, title: "Select single image", mime: "image/*");
    
        }
    
        public void DoIttt()
        {
            NativeGallery.GetImageFromGallery((path) =>
            {
                Debug.Log("Image path: " + path);
                if (path != null)
                {
                    // Create Texture from selected image
                    Texture2D textureee = NativeGallery.LoadImageAtPath(path, 1024); // image will be downscaled if its width or height is larger than 1024px
                    if (textureee == null)
                    {
                        Debug.Log("Couldn't load texture from " + path);
                        return;
                    }
                    img3.texture = textureee;
                   ttt = TextureToTexture2D(img3.texture);
    
    
                    // Use 'texture' here
                    // ...
                }
            }, title: "Select single image", mime: "image/*");
        }
    
        public void Upload()
        {
    
    
    
            byte[] custom_bytes1 = t.EncodeToPNG();
            byte[] custom_bytes2 = tt.EncodeToPNG();
            byte[] custom_bytes3 = ttt.EncodeToPNG();
    
    
    
            // Create a reference to the file you want to upload
            Firebase.Storage.StorageReference rivers_ref = storage_ref.Child(InputManager.ButtonName).Child("img1.png");
    
            // Upload the file to the path "images/rivers.jpg"
            rivers_ref.PutBytesAsync(custom_bytes1)
                .ContinueWith((Task<StorageMetadata> task) =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        Debug.Log(task.Exception.ToString());
                        // Uh-oh, an error occurred!
                    }
                    else
                    { // Metadata contains file metadata such as size, content-type, and download URL.
                        Firebase.Storage.StorageMetadata metadata = task.Result;
                        string download_url = metadata.ToString();
                        // string download_url = metadata.DownloadUrl.ToString();
                        Debug.Log("Finished uploading...");
                        Debug.Log("download url = " + download_url);
    
                    }
                });
    
            Firebase.Storage.StorageReference rivers_ref2 = storage_ref.Child(InputManager.ButtonName).Child("img2.png");
    
            // Upload the file to the path "images/rivers.jpg"
            rivers_ref2.PutBytesAsync(custom_bytes2)
                .ContinueWith((Task<StorageMetadata> task) =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        Debug.Log(task.Exception.ToString());
                        // Uh-oh, an error occurred!
                    }
                    else
                    { // Metadata contains file metadata such as size, content-type, and download URL.
                        Firebase.Storage.StorageMetadata metadata = task.Result;
                        string download_url = metadata.ToString();
                        // string download_url = metadata.DownloadUrl.ToString();
                        Debug.Log("Finished uploading...");
                        Debug.Log("download url = " + download_url);
    
                    }
                });
    
            Firebase.Storage.StorageReference rivers_ref3 = storage_ref.Child(InputManager.ButtonName).Child("img3.png");
            rivers_ref3.PutBytesAsync(custom_bytes3)
               .ContinueWith((Task<StorageMetadata> task) =>
               {
                   if (task.IsFaulted || task.IsCanceled)
                   {
                       Debug.Log(task.Exception.ToString());
                       // Uh-oh, an error occurred!
                   }
                   else
                   { // Metadata contains file metadata such as size, content-type, and download URL.
                       Firebase.Storage.StorageMetadata metadata = task.Result;
                       string download_url = metadata.ToString();
                       // string download_url = metadata.DownloadUrl.ToString();
                       Debug.Log("Finished uploading...");
                       Debug.Log("download url = " + download_url);
    
                   }
               });
    
    
    
        }
        private Texture2D TextureToTexture2D(Texture texture)
        {
            Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
            Graphics.Blit(texture, renderTexture);
    
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();
    
            RenderTexture.active = currentRT;
            RenderTexture.ReleaseTemporary(renderTexture);
            return texture2D;
    
        }
        public void Load()
        {
    
    
            int height = 1024;
            int width = 1024;
    
            target1 = new Texture2D(height, width, TextureFormat.RGB24, false);
            target2 = new Texture2D(height, width, TextureFormat.RGB24, false);
            target3 = new Texture2D(height, width, TextureFormat.RGB24, false);
            const long maxAllowedSize = 1 * 1024 * 1024;
            storage_ref.Child(InputManager.ButtonName).Child("img1.png").GetBytesAsync(maxAllowedSize).
              ContinueWith((Task<byte[]> task) =>
              {
                  UnityThread.executeInUpdate(() =>
                  {
                      if (task.IsFaulted || task.IsCanceled)
                  {
                      Debug.Log(task.Exception.ToString());
                  }
                  else
                  {
                      fileContents1 = task.Result;
                      target1.LoadImage(fileContents1);
                      imgLoad1.texture = target1;
    
                      Debug.Log("Finished downloading!");
                  }
              });});
            storage_ref.Child(InputManager.ButtonName).Child("img2.png").GetBytesAsync(maxAllowedSize).
            ContinueWith((Task<byte[]> task) =>
            {
                UnityThread.executeInUpdate(() =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.Log(task.Exception.ToString());
                }
                else
                {
                    fileContents2 = task.Result;
                    target2.LoadImage(fileContents2);
                    imgLoad2.texture = target2;
    
                    Debug.Log("Finished downloading!");
                }
            }); });
            storage_ref.Child(InputManager.ButtonName).Child("img3.png").GetBytesAsync(maxAllowedSize).
           ContinueWith((Task<byte[]> task) =>
           {
               UnityThread.executeInUpdate(() =>
               {
                   if (task.IsFaulted || task.IsCanceled)
               {
                   Debug.Log(task.Exception.ToString());
               }
               else
               {
                   fileContents3 = task.Result;
                   target3.LoadImage(fileContents3);
                   imgLoad3.texture = target3;
    
                   Debug.Log("Finished downloading!");
               }
           }); });
            //target.LoadRawTextureData(fileContents);
            //target.Apply();
            //target.EncodeToJPG();
            //imgLoad.texture = target;
    
           
            
           
    
    
    
           
           
           
    
    
            Debug.Log("Finished downloading!");
        }
    
    }
