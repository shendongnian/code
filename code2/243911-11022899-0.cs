    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Nektra.Deviare2;
    
    
    namespace DeviareTest
    {
        public partial class Form1 : Form
        {
            private int nSpeed;
            private uint nTime;
    
            private NktSpyMgr _spyMgr;
    
            public Form1()
            {
                InitializeComponent();
    
                _spyMgr = new NktSpyMgr();
                _spyMgr.Initialize();
                _spyMgr.OnFunctionCalled += new DNktSpyMgrEvents_OnFunctionCalledEventHandler(OnFunctionCalled);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                NktHook hook = _spyMgr.CreateHook("WINMM.dll!timeGetTime", (int)(eNktHookFlags.flgOnlyPostCall));
                hook.Hook(true);
    
                bool bProcessFound = false;
                NktProcessesEnum enumProcess = _spyMgr.Processes();
                NktProcess tempProcess = enumProcess.First();
                while (tempProcess != null)
                {
                    if (tempProcess.Name.Equals("iexplore.exe", StringComparison.InvariantCultureIgnoreCase) && tempProcess.PlatformBits == 32)
                    {
                        hook.Attach(tempProcess, true);
                        bProcessFound = true;
                    }
                    tempProcess = enumProcess.Next();
                } 
            
                if(!bProcessFound)
                {
                    MessageBox.Show("Please run \"iexplore.exe\" before!", "Error");
                    Environment.Exit(0);
                }
            }
    
            private void OnFunctionCalled(NktHook hook, NktProcess process, NktHookCallInfo hookCallInfo)
            {
                nTime++;
    
                if (nSpeed==-2)
                    hookCallInfo.Result().LongVal = hookCallInfo.Result().LongVal - (int)(nTime * 0.2);
                else if(nSpeed==2)
                    hookCallInfo.Result().LongVal = hookCallInfo.Result().LongVal + (int)(nTime * 3);
            }
    
            private void SlowButton_CheckedChanged(object sender, EventArgs e)
            {
                nSpeed = -2;
            }
            private void FastButton_CheckedChanged(object sender, EventArgs e)
            {
                nSpeed = 2;
            }
        }
    }
