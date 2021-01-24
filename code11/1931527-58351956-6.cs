    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;
    using System.Text;
    using UnityEditor;
    using UnityEngine;
    
    
    public static class DataBase
    {
        // Do not make the Dictionary public otherwise it can be modified by any class!
        // Rather only provide specific setters and getters
        private static Dictionary<string, User> _users = new Dictionary<string, User>();
    
        // You might even want to give this bit a less obvious name ;)
        private const string fileName = "DataBaseCredentials.cfg";
    
        private static string filePath;
    
        // This method will be automatically called on app start
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            filePath = Path.Combine(Application.persistentDataPath, fileName);
    
            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath);
            }
    
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
    
            LoadUsers();
        }
    
        private static void LoadUsers()
        {
            Debug.Log("DataBase: Loading Users from " + filePath);
    
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                if (stream.Length == 0) return;
    
                var bf = new BinaryFormatter();
                _users = (Dictionary<string, User>)bf.Deserialize(stream);
            }
        }
    
        private static void SaveUsers()
        {
            Debug.Log("DataBase: Storing Users to " + filePath);
    
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, _users);
            }
    
            LoadUsers();
        }
    
        public static User GetUserByName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Debug.LogWarning("username may not be empty!");
                return null;
            }
    
            if (!_users.ContainsKey(username))
            {
                Debug.LogWarning($"A user with name \"{username}\" does not exist!");
                return null;
            }
    
            return _users[username];
        }
        public static bool LogIn(string username, string password)
        {
            var user = GetUserByName(username);
            return user == null ? false : user.CheckPassword(password);
        }
    
        public static void AddUser(string username, string password, Roles role)
        {
            // Check the name
            if (string.IsNullOrWhiteSpace(username))
            {
                Debug.LogWarning("username may not be empty!");
                return;
            }
    
            if (_users.ContainsKey(username))
            {
                Debug.LogWarning($"A user with name \"{username}\" already exists! Chose another username!");
                return;
            }
    
            _users.Add(username, new User(username, password, role));
    
            SaveUsers();
        }
    
        public static void FactorySettings()
        {
            Debug.Log("FactorySettings!");
    
            _users.Clear();
            SaveUsers();
        }
    }
    
    [Serializable]
    public class User
    {
        public string Name;
        public string PasswordHash;
        public Roles Role;
    
    
        public User(string name, string password, Roles role)
        {
            Name = name;
    
            // Never store a naked Password!
            // Rather store the hash and everytime you want to check the password
            // compare the hashes!
            PasswordHash = GetHash(password);
    
            // As said actually you should also not store this as a simple modifiable value
            // Since it almost has the same security impact as a password!
            Role = role;
        }
    
        private static string GetHash(string password)
        {
            var unhashedBytes = Encoding.Unicode.GetBytes(password);
    
            var sha256 = new SHA256Managed();
            var hashedBytes = sha256.ComputeHash(unhashedBytes);
    
            return Convert.ToBase64String(hashedBytes);
        }
    
        public bool CheckPassword(string attemptedPassword)
        {
            var base64AttemptedHash = GetHash(attemptedPassword);
    
            return base64AttemptedHash.Equals(PasswordHash);
        }
    }
    
    public enum Roles
    {
        Teacher,
        Student
    }
