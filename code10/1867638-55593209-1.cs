    public class FilesExample : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            ListMap();
        }
    
        public static FileSystemInfo[] info;
    
        public void ListMap()
        {
            /*
             * If you already called this before you already have child objects
             * So I would destroy the old ones before instantiating new ones
             */
            //foreach(Transform child in Parentcontent)
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            //panellist.SetActive(true);
            /*
             * preferred to use streamingAssetsPath for testing
             */
            //var mainpath = Application.persistentDataPath;
            var mainpath = Application.streamingAssetsPath;
            var dir = new DirectoryInfo(mainpath);
    
            info = dir.GetFileSystemInfos("*.json").OrderBy(i => i.CreationTime).ToArray();
    
            for (var i = 1; i <= info.Length; i++)
            {
                /* 
                 * Instead of instantiating I simply created new empty objects
                 * just as example 
                 */
                
                //var lisobj = Instantiate(prefabpanellist);
                var lisobj = new GameObject(i + " " + info[i - 1].Name);
                //lisobj.transform.SetParent(Parentcontent);
                lisobj.transform.SetParent(transform);
                // Though I'm sure this should already have the correct order
                // you could still do SetLastSibling to move the 
                // created/instantiated object to the bottom
                lisobj.transform.SetAsLastSibling();
    
                //number.text = i.ToString();
                //mapnamedb.text = info[i - 1].Name;
    
                /*
                 * NOTE: I would simply do the buttons thing in the same
                 *       loop. That saves you a lot of storing and accessing lists
                 */
                //var index = i;
                //var button = lisobj.GetComponentInChildren<Button>(true);
                //button.onClick.AddListener(() => Deleteinformation(index));
            }
        }
    
        public void Deleteinformation(int index)
        {
            Debug.Log("Index is " + index);
        
            Debug.Log("Path is " + info[index].FullName);
            File.Delete( info[index].FullName);
            // update the scene list
            ListMap();
        }
    }
