    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    [CreateAssetMenu]
    [Serializable]
    public class Character : ScriptableObject
    {
    // Attributes
    public string firstName;
    public string middleName;
    public string lastName;
    public string fullName;
    public bool isMale;
    // Constructor
    public Character(string _firstName, string _middleName, string _lastName, bool _isMale)
    {
        firstName = _firstName;
        middleName = _middleName;
        lastName = _lastName;
        // All The Functions 
        fullName = string.Format("{0} {1} {2}", firstName, middleName,
        lastName);
        isMale = _isMale;
        // and all the other functions like date calculator.
    }
    public void Initialize(string _firstName, string _middleName, string _lastName, bool _isMale)
    {
        firstName = _firstName;
        middleName = _middleName;
        lastName = _lastName;
        // All The Functions 
        fullName = string.Format("{0} {1} {2}", firstName, middleName,
        lastName);
        isMale = _isMale;
    }
