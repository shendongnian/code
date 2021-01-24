    using UnityEditor;
    using UnityEngine;
    
    public class UsersManager : MonoBehaviour
    {
        public string username;
        public string password;
        public Roles role;
    
        public User User;
    }
    
    [CustomEditor(typeof(UsersManager))]
    public class UsersManagerEditor : Editor
    {
        private UsersManager manager;
    
        private void OnEnable()
        {
            manager = (UsersManager)target;
        }
    
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
    
            if (GUILayout.Button("GetUserByName"))
            {
                manager.User = DataBase.GetUserByName(manager.username);
            }
    
            if (GUILayout.Button("AddUser"))
            {
                DataBase.AddUser(manager.username, manager.password, manager.role);
            }
    
            if (GUILayout.Button("CheckPassword"))
            {
                manager.User = DataBase.GetUserByName(manager.username);
    
                if (manager.User != null)
                {
    
                    if (manager.User.CheckPassword(manager.password))
                    {
                        Debug.Log("Password CORRECT!");
                    }
                    else
                    {
                        Debug.LogWarning("PASSWORD WRONG!");
                    }
                }
            }
    
            if (GUILayout.Button("FactorySettings"))
            {
                DataBase.FactorySettings();
            }
        }
    }
