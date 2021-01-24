csharp
using(var reader = new StreamReader(@"c:\temp\myfile.csv"))
{
    using(var csv = new CsvReader(reader))
    {
       csv.Configuration.RegisterClassMap<ClientMap>();
       csv.Configuration.RegisterClassMap<BookingMap>();
       var bookings = csv.GetRecords<Booking>();
       ... //iterate over bookings and write to Console
       reader.BaseStream.Position = 0;
       csv.Read();
       csv.ReadHeader();
       var clients = csv.GetRecords<Client>();
       ... //iterate over clients and write to Console
    }
}
