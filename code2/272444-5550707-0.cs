    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ChannelAllocator
    {
    
        class Program
        {
            const int _numberOfChannels = 10;
            static void Main(string[] args)
            {
                Dictionary<int, List<TimeSlot>> occupiedChannels = new Dictionary<int, List<TimeSlot>>();
             
                for (int i = 1; i <= _numberOfChannels; i++)
                {
                   
                    occupiedChannels.Add(i, new List<TimeSlot>());
                }
    
                /** Example **/
                TimeSpan start = DateTime.Now.AddHours(-1.0).TimeOfDay;
                TimeSpan end = DateTime.Now.TimeOfDay;
                AssignChannel(occupiedChannels, ref start, ref end);           
    
            }
    
            private static bool AssignChannel(Dictionary<int, List<TimeSlot>> occupiedChannels, ref TimeSpan start, ref TimeSpan end)
            {
                List<int> channels = occupiedChannels.Keys.ToList();
                if (start >= end )
                    return false;
                foreach (var item in channels)
                {
                    List<TimeSlot> slots = occupiedChannels[item];
                    if (slots.Count == 0)
                    {
                        occupiedChannels[item].Add(new TimeSlot(start, end));
                        return true;
    
                    }
                    else
                    {
                        foreach (var slot in slots)
                        {
                            TimeSpan channelStartTime = slot.StartTime;
                            TimeSpan channelEndTime = slot.EndTime;
    
                            if (start >= channelStartTime && end <= channelEndTime ||
                                start <= channelStartTime && end <= channelEndTime && end >= channelStartTime
                                || end >= channelEndTime && start >= channelStartTime && start <= channelEndTime)
                            {
                                continue;
                            }
                            else
                            {
                                occupiedChannels[item].Add(new TimeSlot(start, end));
                                return true;
                            }
    
                        }
                    }
                }
                return false;
            }
    
            private class TimeSlot
            {
                public TimeSpan StartTime;
                public TimeSpan EndTime;
                public TimeSlot(TimeSpan start, TimeSpan end)
                {
                    StartTime = start;
                    EndTime = end;
                }
    
            }
    
        }
    }
