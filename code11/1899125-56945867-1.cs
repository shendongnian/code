 private static List<Flight> SortListByOtherList(List<Flight> UnSortedList, List<string> SortKeys)
        {
            //replace 'object' with your flight class name
            List<Flight> SortedList = new List<Flight>();
            foreach (string Key in SortKeys)
            {
                SortedList.AddRange((from Flight in UnSortedList
                              //Here add the 'get' command of your string Time.Date instand of 'Time'
                              orderby Flight.GetTime() descending
                              //Here add the 'get' command of your string flight stutus instand of 'FlightStutus'
                              where Flight.GetFlightStutus() == Key
                             select Flight).ToList());
                
            }
            return SortedList;
        }
here is the full code if you want to just do it based on my code:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace ConsoleApp6
{
    public class Flight
    {
        string FlightStutus { get; set; }
        DateTime Time { get; set; }
        public Flight(string FlightStutus, DateTime Time)
        {
            this.Time = Time;
            this.FlightStutus = FlightStutus;
        }
        public DateTime GetTime()
        {
            return this.Time;
        }
        public string GetFlightStutus()
        {
            return this.FlightStutus;
        }
        public override string ToString()
        {
            return $"FlightStutus: {this.FlightStutus} Time: {this.Time}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> sortOrder = new List<string> { "Pending", "Ready For Pickup", "Checked Out" };
            List<Flight> ListThatNeedToGetSorted = new List<Flight>();
            ListThatNeedToGetSorted.Add(new Flight("Pending", new DateTime(2005, 12, 12, 9, 0, 0,5)));
            ListThatNeedToGetSorted.Add(new Flight("Ready For Pickup", new DateTime(2005, 12, 12, 9, 0, 0,7)));
            ListThatNeedToGetSorted.Add(new Flight("Checked Out", new DateTime(2005, 12, 12, 9, 0, 0,5)));
            ListThatNeedToGetSorted.Add(new Flight("Checked Out", new DateTime(2012, 12, 10, 9,5, 0)));
            ListThatNeedToGetSorted.Add(new Flight("Pending", new DateTime(2012, 4, 2, 11, 4, 22)));
            List<Flight> SortedList=SortListByOtherList(ListThatNeedToGetSorted, sortOrder);
            foreach (Flight Fl in SortedList)
            {
              Console.WriteLine(Fl);
            }
        }
        
        private static List<Flight> SortListByOtherList(List<Flight> UnSortedList, List<string> SortKeys)
        {
            //replace 'object' with your flight class name
            List<Flight> SortedList = new List<Flight>();
            foreach (string Key in SortKeys)
            {
                SortedList.AddRange((from Flight in UnSortedList
                              //Here add the 'get' command of your string Time.Date instand of 'Time'
                              orderby Flight.GetTime() descending
                              //Here add the 'get' command of your string flight stutus instand of 'FlightStutus'
                              where Flight.GetFlightStutus() == Key
                             select Flight).ToList());
                
            }
            return SortedList;
        }
        }
    }
