    decimal GetAmount(User usr, Func<Tuple<User, User, Notification, Acknowledgement>, User> projection)
    {
        decimal sum = 0;
        foreach (DataGridViewRow row in dgvRecords.Rows)
        {
            Tuple<User, User, Notification, Acknowledgment> tup = (Tuple<User, User, Notification, Acknowledgment>)row.Tag;
            if (projection(tup) == usr)
                sum += tup.Item4.Sum;
    
        }
        return sum;
    }
