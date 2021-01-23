    public void SomeMethod(..., EditMode mode) {
        isEditingCustomer = isEditingOrder =
            isEditingOrderItem = isEditingEmployee = false;
        switch(mode) {
            case EditMode.Customer: isEditingCustomer = true; break;
            case EditMode.Order: isEditingOrder = true; break;
            case EditMode.OrderItem: isEditingOrderItem = true; break;
            case EditMode.Employee: isEditingEmployee = true; break;
            default: throw new ArgumentOutOfRangeException("mode");
        }
    }
