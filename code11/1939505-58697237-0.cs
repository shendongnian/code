 lang-cs
    /// <summary>
    /// Represents a unique time slot by using <see cref="DateTimeOffset"/>.
    /// </summary>
    public class TimeSlot : IComparable<TimeSpan>, ITimeSlot {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSlot"/> class.
        /// </summary>
        /// <param name="start">The start <see cref="ZonedDateTime"/>.</param>
        /// <param name="end">The end <see cref="ZonedDateTime"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the slot would be negative.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        public TimeSlot(ZonedDateTime start, ZonedDateTime end) {
            if (start == default)
                throw new ArgumentNullException(nameof(start));
            if (end == default)
                throw new ArgumentNullException(nameof(end));
            if (end.Instant.UtcDateTime < start.Instant.UtcDateTime)
                throw new ArgumentOutOfRangeException(nameof(end));
            Start = start;
            End = end;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSlot"/> class.
        /// </summary>
        /// <param name="start">The start <see cref="DateTime"/>.</param>
        /// <param name="end">The end <see cref="DateTime"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        /// <remarks>
        /// Beware of the fact that using <see cref="DateTimeKind.Unspecified"/> will be
        /// interpreted as local time. This could cause trouble if used in a server environment.
        /// </remarks>
        public TimeSlot(DateTime start, DateTime end) {
            Start = new ZonedDateTime(start);
            End = new ZonedDateTime(end);
        }
        /// <summary>
        /// Calculate the duration of the time slot.
        /// </summary>
        /// <returns>Time span of the time slot.</returns>
        public TimeSpan Duration => End - Start;
        /// <summary>
        /// Gets or sets the end of the time slot.
        /// </summary>
        /// <value>The end.</value>
        public ZonedDateTime End { get; set; }
        /// <inheritdoc/>
        public TimeSpan Length => End - Start;
        /// <summary>
        /// Gets or sets the start of the time slot.
        /// </summary>
        /// <value>The start.</value>
        public ZonedDateTime Start { get; set; }
        /// <summary>
        /// Adds/Merges two <see cref="TimeSlot"/>s.
        /// </summary>
        /// <param name="left">The left slot.</param>
        /// <param name="right">The right slot.</param>
        /// <returns>The merged <see cref="TimeSlot"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotCombinableTimeSlotsException"></exception>
        public static TimeSlot Add(TimeSlot left, TimeSlot right) {
            if (left == null && right == null)
                throw new ArgumentNullException(nameof(left) + " & " + nameof(right));
            if (left == null)
                return right;
            if (right == null)
                return left;
            if (left.Start != right.End && left.End != right.Start)
                throw new NotCombinableTimeSlotsException();
            if (left == right)
                return left;
            if (left.Start == right.End)
                return new TimeSlot(right.Start, left.End);
            else
                return new TimeSlot(left.Start, right.End);
        }
        /// <summary>
        /// Implements the operator -. The right slot is subtracted from the start if the slots have
        /// the same start. If they have the same end, it is subtracted from the end.
        /// </summary>
        /// <param name="left">The first value</param>
        /// <param name="right">The second value to be subtracted</param>
        /// <returns>The reduced time slot.</returns>
        public static TimeSlot operator -(TimeSlot left, TimeSlot right) => Subtract(left, right);
        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first value to compare</param>
        /// <param name="right">The second value to compare</param>
        /// <returns>
        /// True if the two operands are unequal according to <see cref="Equals(ITimeSlot)"/>; false otherwise
        /// </returns>
        public static bool operator !=(TimeSlot left, TimeSlot right) => !(left == right);
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The first value</param>
        /// <param name="right">The second value to be added</param>
        /// <returns>The combined time slot.</returns>
        /// <exception cref="NotCombinableTimeSlotsException">
        /// Thrown when the slots are not combinable.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown when both operands are null.</exception>
        public static TimeSlot operator +(TimeSlot left, TimeSlot right) {
            if (left == null && right == null)
                throw new ArgumentNullException(nameof(left) + " & " + nameof(right));
            if (left == null)
                return right;
            if (right == null)
                return left;
            if (left.Start != right.End && left.End != right.Start)
                throw new NotCombinableTimeSlotsException();
            if (left == right)
                return left;
            if (left.Start == right.End)
                return new TimeSlot(right.Start, left.End);
            else
                return new TimeSlot(left.Start, right.End);
        }
        public static bool operator <(TimeSlot left, TimeSlot right) {
            return left is null ? right is object : left.CompareTo(right) < 0;
        }
        public static bool operator <=(TimeSlot left, TimeSlot right) {
            return left is null || left.CompareTo(right) <= 0;
        }
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first value to compare</param>
        /// <param name="right">The second value to compare</param>
        /// <returns>
        /// True if the two operands are equal according to <see cref="Equals(ITimeSlot)"/>; false otherwise
        /// </returns>
        public static bool operator ==(TimeSlot left, TimeSlot right) => (left is null && right is null) || (!(left is null) && left.Equals(right));
        public static bool operator >(TimeSlot left, TimeSlot right) {
            return left is object && left.CompareTo(right) > 0;
        }
        public static bool operator >=(TimeSlot left, TimeSlot right) {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
        /// <summary>
        /// Subtracts the right <see cref="TimeSlot"/> from the left.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>The resulting <see cref="TimeSlot"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is <c>null</c>.</exception>
        /// <exception cref="NotCombinableTimeSlotsException"></exception>
        public static TimeSlot Subtract(TimeSlot left, TimeSlot right) {
            if (left == null)
                throw new ArgumentNullException(nameof(left));
            if (right == null)
                throw new ArgumentNullException(nameof(right));
            if (right == null && right.Duration.TotalMilliseconds == 0)
                return left;
            else if (left.Start != right.End && left.End != right.Start)
                throw new NotCombinableTimeSlotsException();
            if (left.Start == right.Start)
                return new TimeSlot(right.End, left.End);
            else
                return new TimeSlot(left.Start, right.End);
        }
        /// <inheritdoc/>
        public int CompareTo(TimeSpan other) => other == default ? -1 : Duration.CompareTo(other);
        /// <summary>
        /// Compares to the duration of two time slots.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// -1 : This instance is shorter than value. 0 : This instance is equal to value. 1 : This
        ///  instance is longer than value.
        /// </returns>
        public int CompareTo(ITimeSlot other) => other == null ? -1 : CompareTo(other.Duration);
        /// <inheritdoc/>
        public ITimeSlot Copy() => new TimeSlot(Start, End);
        /// <inheritdoc />
        public IEnumerable<ITimeSlot> DivideAt(TimeSpan timeOfTheDay = default) {
            if (Start.TimeZone != End.TimeZone)
                throw new NotSupportedException(Resources.DifferentTimeZonesAreNotSupported);
            return DivideAtIterator();
            IEnumerable<ITimeSlot> DivideAtIterator() {
                // set the next split instant
                var nextSplit = new ZonedDateTime(Start.Instant.Date.Add(timeOfTheDay), Start.TimeZone);
                ZonedDateTime lastEnd = Start;
                if (Start >= nextSplit)
                    nextSplit = nextSplit.AddDays(1);
                // loop until we are beyond the end
                while (nextSplit < End) {
                    yield return new TimeSlot(lastEnd, nextSplit);
                    lastEnd = nextSplit;
                    nextSplit = nextSplit.AddDays(1);
                }
                yield return new TimeSlot(lastEnd, End);
            }
        }
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// True if the specified value is the same instant in the same time zone; false otherwise.
        /// </returns>
        public bool Equals(ITimeSlot other) => !(other is null) && Start.Equals(other.Start) && End.Equals(other.End);
        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same
        /// value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// True if the specified value is a <see cref="ZonedDateTime"/> representing the same
        /// instant in the same time zone; false otherwise.
        /// </returns>
        public override bool Equals(object obj) => obj is TimeSlot timeSlot && Equals(timeSlot);
        /// <summary>
        /// Computes the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() {
            var hash = new HashCodeCombiner();
            hash.AddDateTime(Start.Instant.LocalDateTime); // represents the time in the given time zone
            hash.AddDateTime(End.Instant.LocalDateTime); // represents the time in the given time zone
            return hash.GetCombinedHashCode().GetHashCode();
        }
        /// <inheritdoc/>
        public bool Includes(ZonedDateTime value) => (Start <= value) && (value <= End);
        /// <inheritdoc/>
        public bool Includes(IRange<ZonedDateTime> range) {
            if (range is null) {
                throw new ArgumentNullException(nameof(range));
            }
            return Start <= range.Start && range.End <= End;
        }
        /// <inheritdoc/>
        public IList<ITimeSlot> InsertGap(ZonedDateTime insertAt, TimeSpan size = default) {
            IList<ITimeSlot> splittedSlots = SplitSlot(insertAt);
            if (splittedSlots.Count == 2 && size != TimeSpan.Zero) {
                ITimeSlot leadingSlot = splittedSlots[0];
                ITimeSlot trailingSlot = splittedSlots.Last();
                if (size > TimeSpan.Zero)
                    trailingSlot.MoveBySpan(size);
                else
                    leadingSlot.MoveBySpan(size);
            }
            return splittedSlots;
        }
        /// <inheritdoc/>
        public bool IntersectsWith(IRange<ZonedDateTime> range) {
            if (range is null) {
                throw new ArgumentNullException(nameof(range));
            }
            // don't check for includes, as the same start/end instant means no intersection, it means seamless connected
            return Start < range.Start && range.Start < End || Start < range.End && range.End < End;
        }
        /// <inheritdoc/>
        public void MoveBySpan(TimeSpan offset) {
            Start += offset;
            End += offset;
        }
        /// <inheritdoc/>
        public void MoveTo(ZonedDateTime newStart) {
            TimeSpan offset = newStart - Start;
            MoveBySpan(offset);
        }
        /// <inheritdoc/>
        public IList<ITimeSlot> SplitSlot(ZonedDateTime splitAt) {
            var splittedSlots = new List<ITimeSlot>();
            if (Includes(splitAt)) {
                var leadingSlot = new TimeSlot(Start, splitAt);
                var trailingSlot = new TimeSlot(splitAt, End);
                // prepare the return value
                splittedSlots.Add(leadingSlot);
                splittedSlots.Add(trailingSlot);
            }
            return splittedSlots;
        }
    }
ZonedDateTime is my own type. Replacing it with a normal DateTime or the NodaTime ZonedDatetime should work too.
To find the gaps in your maximum time range, your layer 3, you can use this extension method.
lang-cs
        /// <summary>
        /// Find the gaps between the given time slots. (Gaps and Islands)
        /// </summary>
        /// <param name="slots">The unordered list of time slots.</param>
        /// <param name="maxRange">
        /// The maximum time range. Use if you want leading/trailing gaps. (optional)
        /// </param>
        /// <returns>The gaps between the given time slots.</returns>
        public static IEnumerable<ITimeSlot> FindGaps(this IEnumerable<ITimeSlot> slots, ITimeSlot maxRange = null)
        {
            ZonedDateTime min = maxRange?.Start ?? (slots.Any() ? slots.Min(r => r.Start) : ZonedDateTime.MinValue);
            ZonedDateTime max = maxRange?.End ?? (slots.Any() ? slots.Max(r => r.End) : ZonedDateTime.MaxValue);
            foreach (var slot in slots.OrderBy(r => r.Start)) {
                // fill the return value ignore slots without duration
                ZonedDateTime slotStart = slot.Start;
                // prevent 0 duration slots and overlaps
                if (min < slotStart)
                    yield return new TimeSlot(min, slotStart);
                // remember the beginning of the next slot
                min = slot.End;
            }
            // return the trailing gap, if there is any
            if (min < max)
                yield return new TimeSlot(min, max);
        }
With those helping structures and methods in place I created a unit test (xunit) with an algorithm for your first scenario:
lang-cs
    public class MyTestClass {
        [Fact]
        public void MyTestMethod() {
            // Arrange
            var absences = new List<ITimeSlot> {
                new TimeSlot(ZonedDateTime.Today.AddHours(5), ZonedDateTime.Today.AddHours(8)),
                new TimeSlot(ZonedDateTime.Today.AddHours(9), ZonedDateTime.Today.AddHours(10)),
            };
            var maxSlot = new TimeSlot(ZonedDateTime.Today.AddHours(3), ZonedDateTime.Today.AddHours(18));
            var appointments = new List<ITimeSlot> {
                new TimeSlot(ZonedDateTime.Today.AddHours(4), ZonedDateTime.Today.AddHours(5)),
                new TimeSlot(ZonedDateTime.Today.AddHours(5), ZonedDateTime.Today.AddHours(11))
            };
            // Act
            var result = MyMethod(appointments, absences, maxSlot);
            // Assert
            Assert.Equal(6, result.Count);
            // ... other tests
        }
        public List<ITimeSlot> MyMethod(List<ITimeSlot> appointments, List<ITimeSlot> absences, ITimeSlot maxSlot) {
            var result = new List<ITimeSlot>();
            result.AddRange(absences);
            foreach (var item in appointments) {
                // appointments in absences are wiped
                if (!absences.Any(a => a.Includes(item))) {
                    var touches = absences.Any(a => item.Includes(a) || a.IntersectsWith(item));
                    if (touches) {
                        item.Start = absences.SingleOrDefault(a => a.IntersectsWith(item))?.End ?? item.Start;
                        item.End = absences.SingleOrDefault(a => a.IntersectsWith(item))?.Start ?? item.End;
                    } else
                        result.Add(item);
                }
            }
            var gaps = result.FindGaps(maxSlot);
            result.AddRange(gaps);
            return result;
        }
Now you can add tests for all possible variants and improve the algorithm.
