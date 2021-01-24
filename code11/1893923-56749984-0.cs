    using UnityEngine;
    using TMPro;
    using System;
    
    public class SelectedDate
    {
        public static DateTime date = DateTime.Now;
    }
    public class DateCallback : AndroidJavaProxy
    {
        public DateCallback() : base("android.app.DatePickerDialog$OnDateSetListener") { }
    
        public void onDateSet(AndroidJavaObject view, int year, int monthOfYear, int dayOfMonth)
        {
            SelectedDate.date = new DateTime(year, monthOfYear + 1, dayOfMonth);
        }
    }
    public class DatePicker : MonoBehaviour
    {
        public TMP_Text startingDateText;
        public TMP_Text goalDateText;
        private AndroidJavaObject activity;
        private DateTime newSelectedStartingDate;
        private DateTime newSelectedGoalDate;
    
        void PickDate()
        {
            new AndroidJavaObject("android.app.DatePickerDialog", activity, new DateCallback(), SelectedDate.date.Year, SelectedDate.date.Month - 1, SelectedDate.date.Day).Call("show");
        }
    
        void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 450, 100), string.Format("ddd d MMMM, yyyy", SelectedDate.date)))
            {
                activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call("runOnUiThread", new AndroidJavaRunnable(PickDate));
            }
        }
    }
