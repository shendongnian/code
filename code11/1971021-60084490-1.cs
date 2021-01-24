    var Customerorders = db.Orders.Where(
        item => item.OrderNr == 1005
    ).Select(
        item => new
        {
            item.CheckInAndOutId,
            item.CheckInDate,
            item.CheckOutDate,
            item.Department.DepartmentName,
            Personal = item.Employee.FirstName + " " + item.Employee.LastName,
            RoomNr = item.RoomId.HasValue ? item.Room.RoomNr : (int?)null
        }
    );
