    public static class BinaryWriterNodaTimeExtensions
    {
        public static void WriteInstant(this BinaryWriter writer, Instant instant) =>
            writer.WriteDuration(instant - NodaConstants.UnixEpoch);
        public static void WriteDuration(this BinaryWriter writer, Duration duration)
        {
            writer.Write(duration.Days);
            writer.Write(duration.NanosecondOfDay);
            // Alternative implementation if you don't need durations bigger than +/- 292 years
            // writer.Write(duration.ToInt64Nanoseconds());
        }
        public static void WriteLocalDateTime(this BinaryWriter writer, LocalDateTime localDateTime)
        {
            writer.WriteLocalDate(localDateTime.Date);
            writer.WriteLocalTime(localDateTime.TimeOfDay);
        }
        public static void WriteZonedDateTime(this BinaryWriter writer, ZonedDateTime zonedDateTime)
        {
            writer.WriteLocalDateTime(zonedDateTime.LocalDateTime);
            // Note: no indication of the DateTimeZoneProvider. There's no standard way of representing
            // that, but most applications would use the same one everywhere.
            writer.Write(zonedDateTime.Zone.Id);
            writer.WriteOffset(zonedDateTime.Offset);
        }
        public static void WriteLocalDate(this BinaryWriter writer, LocalDate localDate)
        {
            // Casting to byte to optimize for space, as requested in the question.
            writer.Write((byte) localDate.Year);
            writer.Write((byte) localDate.Month);
            writer.Write((byte) localDate.Day);
            // You could omit this if you'll only ever use the ISO calendar.
            writer.Write(localDate.Calendar.Id);
        }
        public static void WriteLocalTime(this BinaryWriter writer, LocalTime localTime) =>
            writer.Write(localTime.NanosecondOfDay);
        public static void WriteOffset(this BinaryWriter writer, Offset offset) =>
            writer.Write(offset.Seconds);
        public static void WriteOffsetDateTime(this BinaryWriter writer, OffsetDateTime offsetDateTime)
        {
            writer.WriteLocalDateTime(offsetDateTime.LocalDateTime);
            writer.WriteOffset(offsetDateTime.Offset);
        }
    }
