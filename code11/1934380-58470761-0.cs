    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public struct Group
        {
            public Group(TimeSpan startTime, TimeSpan endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }
    
            public TimeSpan StartTime { get; }
    
            public TimeSpan EndTime { get; }
    
            public override string ToString()
            {
                return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}";
            }
    
            public bool Equals(Group other)
            {
                return StartTime.Equals(other.StartTime) && EndTime.Equals(other.EndTime);
            }
    
            public override bool Equals(object obj)
            {
                return obj is Group other && Equals(other);
            }
    
            public override int GetHashCode()
            {
                unchecked
                {
                    return (StartTime.GetHashCode() * 397) ^ EndTime.GetHashCode();
                }
            }
    
            public static bool operator ==(Group left, Group right)
            {
                return left.Equals(right);
            }
    
            public static bool operator !=(Group left, Group right)
            {
                return !left.Equals(right);
            }
        }
    
        internal static class Program
        {
            private static void Main(string[] args)
            {
                var groups = new[]
                {
                    new Group(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0)),
                    new Group(new TimeSpan(9, 30, 0), new TimeSpan(10, 15, 0)),
                    new Group(new TimeSpan(10, 0, 0), new TimeSpan(10, 30, 0)),
                    new Group(new TimeSpan(11, 0, 0), new TimeSpan(11, 30, 0)),
                    new Group(new TimeSpan(11, 45, 0), new TimeSpan(13, 0, 0)),
                    new Group(new TimeSpan(12, 45, 0), new TimeSpan(14, 0, 0))
                };
    
                foreach (var group in groups)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine(group);
    
                    var array = GetOverlapping(group, groups).ToArray();
    
                    foreach (var item in array)
                        Console.WriteLine(item);
                }
    
                Console.ReadKey();
            }
    
            public static IEnumerable<Group> GetOverlapping(Group group, IEnumerable<Group> groups)
            {
                var except = groups.Except(new[] {group});
    
                foreach (var item in except)
                    if (item.StartTime >= group.StartTime && item.StartTime < group.EndTime)
                        yield return item;
            }
        }
    }
