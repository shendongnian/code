using System.Text.RegularExpressions;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;
public class RegEx : MonoBehaviour
{
    public InputField emailField;
    public Button acceptSubmissionButton;
    public string emailSub;
    public void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }
    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        IsEmailValid(arg0);
        ValidCheck(arg0);
    }
    public void Sequencer(string emailSub)
    {
        Debug.Log(emailSub);
        IsEmailValid(emailSub);
        ValidCheck(emailSub);
    }
    public static bool IsEmailValid(string arg0)
    {
        if (arg0.Length <= 6)
        {
            return false;
        }
        try
        {
            return Regex.IsMatch(arg0, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)); // The pattern is taken from an article written by Microsoft. https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
 
    }
    public static void ValidCheck(string arg0)
    {
        if (IsEmailValid(arg0))
        {
            Debug.Log($"Valid:   {arg0}");
        }
        else
        {
            Debug.Log($"Invalid: {arg0}");
        }
    }
}
