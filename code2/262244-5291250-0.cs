    using System;
    using System.Text;
    using System.Net;
    using com.ximpleware;
    
                public static void insertWS()
                {            
                        VTDGen vg = new VTDGen();
                        if (vg.parseFile("input.xml",false){
                            VTDNav vn = vg.getNav();
                            AutoPilot ap = new AutoPilot(vn);
                            XMLModifier xm = new XMLModifier(vn);
                            ap.selectXPath("/products/product/*");
                            while(ap.evalXPath()!=-1){
                                xm.insertAfterElement("\n");
                            }
                            xm.output("output.xml");
                        }
                }
