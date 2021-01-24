    class Products
    {
        public string ProdName { get; set; }
    }
    class Elements
    {
        public string ElemName { get; set; }
    }
    class Processes
    {
        public string ProcName { get; set; }
    }
    class ProductElements
    {
        public Products Product { get; set; }
        public Elements Element { get; set; }
    }
    class ElementProcesses
    {
        public Elements Element { get; set; }
        public Processes Process { get; set; }
    }
            var p01 = new Products() { ProdName = "P01" };
            var p02 = new Products() { ProdName = "P02" };
            var e01 = new Elements() { ElemName = "E01" };
            var e05 = new Elements() { ElemName = "E05" };
            var e06 = new Elements() { ElemName = "E06" };
            var e08 = new Elements() { ElemName = "E08" };
            var pc01 = new Processes() { ProcName = "PC01" };
            var pc02 = new Processes() { ProcName = "PC02" };
            var pc07 = new Processes() { ProcName = "PC07" };
            var pc08 = new Processes() { ProcName = "PC08" };
            var pc09 = new Processes() { ProcName = "PC09" };
            var productElements01 = new List<ProductElements>() {
                new ProductElements(){ Product = p01, Element = e01},
                new ProductElements(){ Product = p01, Element = e06},
                new ProductElements(){ Product = p02, Element = e05},
                new ProductElements(){ Product = p02, Element = e08}};
            var elemProc01 = new List<ElementProcesses>()   {
                new ElementProcesses(){Element = e01, Process = pc01},
                {new ElementProcesses(){Element = e01, Process = pc02}},
                {new ElementProcesses(){Element = e06, Process = pc08}},
                {new ElementProcesses(){Element = e05, Process = pc07}},
                {new ElementProcesses(){Element = e08, Process = pc09}}};
          
