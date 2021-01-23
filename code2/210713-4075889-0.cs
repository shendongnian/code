    private EditMode editMode;   
    public bool IsEditingCustomer { get {return editMode == EditMode.Customer;}}
    public bool IsEditingOrder { get {return editMode == EditMode.Order;}}
    public bool IsEditingOrderItem { get {return editMode == EditMode.OrderItem;}}
    public bool IsEditingEmployee { get {return editMode == EditMode.Employee;}}
